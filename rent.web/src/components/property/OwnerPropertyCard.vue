<template>
  <div class="p-3 m-2 border border-gray-100 rounded-sm">
    <div class="flex">
      <div class="min-h-fit min-w-fit h-24 w-24">
        <img
          v-if="props.property.thumbnailUrl"
          :src="props.property.thumbnailUrl"
          class="h-24 w-24 object-cover rounded-xl shadow-sm"
        />
        <img
          v-else
          src="@/assets/house-template.png"
          class="h-24 w-24 object-cover rounded-xl shadow-sm"
        />
      </div>
      <div class="ml-4 grow min-w-min">
        <h3 class="text-lg">{{ props.property.name }}</h3>
        <div>{{ propType }}</div>
        <div>{{ address }}</div>
      </div>
      <div class="text-center">
        <button @click="editProperty" type="button">Edit</button>
        <button @click="showDeleteModal = true" type="button" class="text-red-500 ml-1">
          Delete
        </button>
      </div>
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
import DeletePropertyModal from './DeletePropertyModal.vue'

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
