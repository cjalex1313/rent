<template>
  <div>
    <div class="md:grid md:grid-flow-col md:justify-stretch md:gap-4">
      <SelectInput v-model="filters.country" :options="countryOptions" label="Country" class="" />
      <AppInput class="" label="City" v-model="filters.city" />
    </div>
    <div class="mt-5 text-center">
      <AppButton @click="search" text="Search" />
    </div>
  </div>
</template>

<script setup>
import { reactive } from 'vue'
import SelectInput from '../../common/form/SelectInput.vue'
import AppInput from '../../common/form/AppInput.vue'
import countries from '../../../data/countries'
import AppButton from '../../common/form/AppButton.vue'

const emit = defineEmits(['search'])

const countryOptions = countries

const filters = reactive({
  country: countryOptions[0].id,
  city: ''
})

const search = () => {
  emit('search', filters)
}
</script>
