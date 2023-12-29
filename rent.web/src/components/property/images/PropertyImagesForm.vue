<template>
  <div class="my-2">
    <h4 class="text-xl font-bold mb-2">Images</h4>
    {{ props.propertyId }}
    {{ props.propertyHumbnailId }}
  </div>
</template>

<script setup>
import propertyApi from '../../../api/properties/propertyApi'
const props = defineProps(['propertyId', 'propertyThumbnailId'])

const loadImages = async () => {
  const images = await propertyApi.getPropertyIamges(props.propertyId)
  console.log(images)
}

loadImages()
</script>
