<template>
  <div class="my-2">
    <h4 class="text-xl font-bold mb-2">Images</h4>
    {{ props.propertyId }}
    {{ props.propertyHumbnailId }}
    <div class="flex m-4">
      <PropertyImageForm v-for="image in imagesData" :key="image.id" :image="image" />
    </div>
    <div class="text-center">
      <button
        @click="uploadImages"
        type="button"
        class="rounded-md bg-white px-2.5 py-1.5 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
      >
        Upload
      </button>
    </div>
  </div>
</template>

<script setup>
import { defineProps, reactive } from 'vue'
import PropertyImageForm from './PropertyImageForm.vue'
import filePrompt from '../../../helpers/filePrompt'
import propertyApi from '../../../api/properties/propertyApi'

const props = defineProps(['propertyId', 'propertyThumbnailId'])

const imagesData = reactive([])

const loadImages = async () => {
  const images = await propertyApi.getPropertyIamges(props.propertyId)
  imagesData.splice(0, imagesData.length, ...images)
}

const uploadImages = async () => {
  const files = await filePrompt('.png, .jpg, .jpeg', true)
  for (const file of files) {
    let fileSize = file.size / 1024 / 1024
    if (fileSize > 10) {
      alert('File size must be less than 10MB')
      return
    }
  }
  await propertyApi.addPropertyImages(props.propertyId, files)
  await loadImages()
}

loadImages()
</script>
