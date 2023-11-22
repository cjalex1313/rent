<template>
  <div>
    <div class="">
      <button
        @click="showModal = true"
        type="button"
        class="rounded-lg bg-indigo-600 m-3 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        Add property
      </button>
    </div>
    <div v-if="properties" class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3">
      <OwnerPropertyCard
        v-for="property of properties"
        @propertyDeleted="loadProperties"
        :property="property"
        :key="property.id"
      />
    </div>
    <AddPropertyModal v-if="showModal" @close="showModal = false" @success="loadProperties()" />
  </div>
</template>

<script setup>
import { ref } from 'vue'
import AddPropertyModal from '../../components/property/AddPropertyModal.vue'
import OwnerPropertyCard from '../../components/property/OwnerPropertyCard.vue'
import propertyApi from '../../api/properties/propertyApi'

const showModal = ref(false)
const properties = ref([])

const loadProperties = async () => {
  let userProps = await propertyApi.getUserProperties()
  properties.value = userProps
}

loadProperties()
</script>
