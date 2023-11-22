<template>
  <BaseModal @close="emit('close')" title="Add property">
    <template #body>
      <h2 class="text-base font-semibold leading-7 text-gray-900">Property Information</h2>
      <p class="mt-1 text-sm leading-6 text-gray-600">
        Fill out the basic information for your property
      </p>

      <SelectInput v-model="propType" label="Type" :options="typeOptions" />

      <div class="mt-6 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
        <AppInput
          class="sm:col-span-6"
          label="Name"
          v-model="property.name"
          :errors="v$.name.$errors"
        />

        <SelectInput
          v-model="property.country"
          :options="countryOptions"
          label="Country"
          class="sm:col-span-3"
        />

        <AppInput
          class="sm:col-span-3"
          label="City"
          v-model="property.city"
          :errors="v$.city.$errors"
        />

        <AppInput
          class="col-span-full"
          label="Street address"
          v-model="property.street"
          :errors="v$.street.$errors"
        />

        <AppInput
          class="sm:col-span-2"
          label="Number"
          v-model="property.number"
          :errors="v$.number.$errors"
        />

        <AppInput
          class="sm:col-span-2"
          label="ZIP / Postal Code"
          v-model="property.postalCode"
          :errors="v$.postalCode.$errors"
        />

        <AppNumberInput
          class="sm:col-span-2"
          label="Size"
          v-model="property.size"
          :errors="v$.size.$errors"
        />
      </div>
    </template>
    <template #footer>
      <div class="mt-3 sm:flex sm:flex-row-reverse">
        <button
          @click="saveProperty()"
          type="button"
          class="inline-flex w-full justify-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 sm:ml-3 sm:w-auto"
        >
          Save
        </button>
        <button
          @click="$emit('close')"
          type="button"
          class="mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto"
        >
          Cancel
        </button>
      </div>
    </template>
  </BaseModal>
</template>

<script setup>
import { ref, reactive } from 'vue'
import useVuelidate from '@vuelidate/core'
import { helpers, required, minValue } from '@vuelidate/validators'
import { propertyTypes, propertyEnum } from '../../data/propertyTypes'
import countries from '../../data/countries'
import BaseModal from '../common/BaseModal.vue'
import SelectInput from '../common/form/SelectInput.vue'
import AppInput from '../common/form/AppInput.vue'
import AppNumberInput from '../common/form/AppNumberInput.vue'
import apartmentApi from '../../api/properties/apartmentApi'
import houseApi from '../../api/properties/houseApi'

const typeOptions = propertyTypes
const countryOptions = countries

const emit = defineEmits(['close', 'success'])

const propType = ref(propertyEnum.Apartment)
const property = reactive({
  name: '',
  country: countryOptions[0].id,
  city: '',
  state: null,
  street: '',
  number: '',
  postalCode: '',
  size: 0
})

const rules = {
  name: { required: helpers.withMessage('Name is required', required) },
  city: { required: helpers.withMessage('City is required', required) },
  street: { required: helpers.withMessage('Street is required', required) },
  number: { required: helpers.withMessage('Number is required', required) },
  postalCode: { required: helpers.withMessage('Postal code is required', required) },
  size: { minValue: helpers.withMessage('Size cannot be negative', minValue(0)) }
}

const v$ = useVuelidate(rules, property)

const saveProperty = async () => {
  v$.value.$touch()
  const isValid = await v$.value.$validate()
  if (!isValid) return
  if (propType.value == propertyEnum.Apartment) {
    await apartmentApi.createBasicApartment(
      property.name,
      property.country,
      property.city,
      property.state,
      property.street,
      property.postalCode,
      property.size,
      property.number
    )
  } else if (propType.value == propertyEnum.House) {
    await houseApi.createBasicHouse(
      property.name,
      property.country,
      property.city,
      property.state,
      property.street,
      property.postalCode,
      property.size,
      property.number
    )
  }
  emit('success')
  emit('close')
}
</script>
