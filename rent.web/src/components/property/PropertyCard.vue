<template>
  <div class="flex justify-between p-3 m-2 border border-gray-100 rounded-sm">
    <div>
      <h3 class="text-lg">{{ props.property.name }}</h3>
      <div>{{ propType }}</div>
      <div>{{ address }}</div>
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue'
import { propertyTypes } from '../../data/propertyTypes'

const props = defineProps(['property'])

const address = computed(() => {
  let prop = props.property
  if (!prop) return ''
  return `${prop.country}, ${prop.city}, ${prop.street}, ${prop.postalCode}`
})

const propType = computed(() => {
  let prop = props.property
  if (!prop) return ''
  let t = propertyTypes.find((pt) => pt.id == prop.propertyType)
  if (!t) return ''
  return t.text
})
</script>
