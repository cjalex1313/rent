<template>
  <div>
    <PropertyForm :property="house" ref="propertyForm" />
    <div class="mt-6">
      <h4 class="text-xl">House information</h4>
      <div class="mt-6 grid gap-x-6 grid-cols-1 sm:grid-cols-3">
        <AppNumberInput label="Land size" v-model="house.landSize" :errors="v$.landSize.$errors" />
        <AppNumberInput label="Levels" v-model="house.levels" :errors="v$.levels.$errors" />
      </div>
    </div>
    <div class="flex justify-end mr-6">
      <button @click="saveHouse" type="button">Save</button>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import useVuelidate from '@vuelidate/core'
import { helpers, required, integer } from '@vuelidate/validators'
import PropertyForm from '../PropertyForm.vue'
import AppNumberInput from '../../common/form/AppNumberInput.vue'

const props = defineProps(['house'])
const emit = defineEmits(['saveHouse'])
const house = props.house
const propertyForm = ref(null)

const rules = {
  landSize: {
    required: helpers.withMessage('Land size is required', required),
    integer: helpers.withMessage('Land size must be a integer number', integer)
  },
  levels: {
    required: helpers.withMessage('Levels is required', required),
    integer: helpers.withMessage('Levels must be a integer number', integer)
  }
}

const v$ = useVuelidate(rules, house)

const saveHouse = async () => {
  let baseIsValid = await propertyForm.value.isValid()
  if (!baseIsValid) return
  v$.value.$touch()
  const isValid = await v$.value.$validate()
  if (!isValid) return
  emit('saveHouse')
}
</script>
