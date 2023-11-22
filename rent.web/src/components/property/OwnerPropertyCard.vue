<template>
  <div class="flex justify-between p-3 m-2 border border-gray-100 rounded-sm">
    <div>
      <h3 class="text-lg">{{ props.property.name }}</h3>
      <div>{{ propType }}</div>
      <div>{{ address }}</div>
    </div>
    <div class="min-w-fit">
      <button @click="editProperty" type="button">Edit</button>
      <button @click="showDeleteModal = true" type="button" class=" text-red-500 ml-1">Delete</button>
    </div>
    <DeletePropertyModal
      v-if="showDeleteModal"
      @close="showDeleteModal = false"
      @success="emit('propertyDeleted')"
      :property="props.property"
    />
  </div>
</template>

<script setup>
import { computed, ref } from 'vue'
import { useRouter } from 'vue-router'
import { propertyEnum, propertyTypes } from '../../data/propertyTypes'
import DeletePropertyModal from './DeletePropertyModal.vue';

const props = defineProps(['property'])
const router = useRouter()
const emit = defineEmits(['propertyDeleted'])

const showDeleteModal = ref(false)

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

const editProperty = () => {
  let property = props.property
  switch (property.propertyType) {
    case propertyEnum.Apartment:
      router.push({
        name: 'Apartment',
        params: {
          id: property.id
        }
      })
      break
    case propertyEnum.House:
      router.push({
        name: 'House',
        params: {
          id: property.id
        }
      })
      break
  }
}
</script>
