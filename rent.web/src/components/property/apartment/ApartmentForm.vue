<template>
  <div>
    <PropertyForm :property="apartment" ref="propertyForm" />
    <div class="mt-6">
      <h4 class="text-xl">Apartment information</h4>
      <div class="mt-6 grid gap-x-6 grid-cols-1 sm:grid-cols-3">
        <AppNumberInput label="Floor" v-model="apartment.floor" :errors="v$.floor.$errors" />
        <AppNumberInput
          label="Building max floor"
          v-model="apartment.buildingMaxFloor"
          :errors="v$.buildingMaxFloor.$errors"
        />
        <AppNumberInput
          label="Apartment number"
          v-model="apartment.apartmentNumber"
          :errors="v$.apartmentNumber.$errors"
        />
      </div>
    </div>
    <div class="flex justify-end mr-6 mt-3">
      <button @click="saveApartment" type="button">Save</button>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import useVuelidate from '@vuelidate/core'
import { helpers, required, integer } from '@vuelidate/validators'
import PropertyForm from '../PropertyForm.vue'
import AppNumberInput from '../../common/form/AppNumberInput.vue'

const props = defineProps(['apartment'])
const emit = defineEmits(['saveApartment'])
const apartment = props.apartment
const propertyForm = ref(null)

const rules = {
  floor: {
    required: helpers.withMessage('Floor is required', required),
    integer: helpers.withMessage('Floor must be a integer number', integer)
  },
  buildingMaxFloor: {
    required: helpers.withMessage('Building max floor is required', required),
    integer: helpers.withMessage('Building max floor must be a integer number', integer)
  },
  apartmentNumber: {
    required: helpers.withMessage('Apartment number is required', required),
    integer: helpers.withMessage('Apartment number must be a integer number', integer)
  }
}

const v$ = useVuelidate(rules, apartment)

const saveApartment = async () => {
  let baseIsValid = await propertyForm.value.isValid()
  if (!baseIsValid) return
  v$.value.$touch()
  const isValid = await v$.value.$validate()
  if (!isValid) return
  emit('saveApartment')
}
</script>
