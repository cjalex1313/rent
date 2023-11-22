<template>
  <div class="mt-5">
    <SearchFilters @search="updateFilters" />
    <div v-if="data.properties.length > 0">
      <PropertyCard v-for="property in data.properties" :key="property.id" :property="property" />
    </div>
  </div>
</template>

<script setup>
import { reactive } from 'vue'
import SearchFilters from '../../components/property/search/SearchFilters.vue'
import PropertyCard from '../../components/property/PropertyCard.vue'
import propertyApi from '../../api/properties/propertyApi'

const filtersState = reactive({
  country: '',
  city: '',
  state: '',
  page: 0
})

const data = reactive({
  properties: [],
  total: null
})

const updateFilters = (filters) => {
  filtersState.country = filters.country
  filtersState.city = filters.city
  filtersState.page = 0
  search()
}

const search = async () => {
  const retrievedProperties = await propertyApi.search(
    filtersState.country,
    filtersState.city,
    null,
    filtersState.page
  )
  data.properties = retrievedProperties.properties
  data.total = retrievedProperties.total
}
</script>
