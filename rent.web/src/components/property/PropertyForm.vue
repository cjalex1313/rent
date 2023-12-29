<template>
  <div>
    <h4 class="text-xl font-bold">Basic property information</h4>
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
  </div>
</template>

<script setup>
import useVuelidate from '@vuelidate/core'
import { helpers, required, minValue } from '@vuelidate/validators'
import AppInput from '../common/form/AppInput.vue'
import SelectInput from '../common/form/SelectInput.vue'
import countries from '../../data/countries'
import AppNumberInput from '../common/form/AppNumberInput.vue'

const countryOptions = countries
const props = defineProps(['property'])

const property = props.property

const rules = {
  name: { required: helpers.withMessage('Name is required', required) },
  city: { required: helpers.withMessage('City is required', required) },
  street: { required: helpers.withMessage('Street is required', required) },
  number: { required: helpers.withMessage('Number is required', required) },
  postalCode: { required: helpers.withMessage('Postal code is required', required) },
  size: { minValue: helpers.withMessage('Size cannot be negative', minValue(0)) }
}

const v$ = useVuelidate(rules, property)

const isValid = async () => {
  v$.value.$touch()
  const isValid = await v$.value.$validate()
  return isValid
}

defineExpose({
  isValid
})
</script>
