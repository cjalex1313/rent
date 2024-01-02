<template>
  <div>
    <img
      v-if="props.image"
      @click="imageFormData.modalIsOpen = true"
      :src="props.image.url"
      class="w-32 h-32 object-cover rounded-md shadow-sm m-4"
    />
    <PropertyImageModal
      v-if="imageFormData.modalIsOpen"
      @close="imageFormData.modalIsOpen = false"
      :image="props.image"
      :propertyId="props.propertyId"
    />
  </div>
</template>

<script setup>
import { defineProps, reactive } from 'vue'
import PropertyImageModal from './PropertyImageModal.vue'

const props = defineProps(['image', 'propertyId'])

const imageFormData = reactive({
  modalIsOpen: false
})
</script>
```
