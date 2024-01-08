<template>
  <BaseModal @close="emit('close')" title="Manage image">
    <template #body>
      <div class="flex justify-center">
        <img :src="props.image.url" class="h-64 max-w-full object-cover rounded-md shadow-sm" />
      </div>
    </template>
    <template #footer>
      <div class="mt-3 sm:flex sm:flex-row-reverse">
        <button
          @click="deleteImage"
          type="button"
          class="inline-flex w-full justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 sm:ml-3 sm:w-auto"
        >
          Delete
        </button>
        <button
          @click="$emit('close')"
          type="button"
          class="mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto"
        >
          Cancel
        </button>
      </div>
    </template>
  </BaseModal>
</template>

<script setup>
import { defineEmits, defineProps } from 'vue'
import propertyApi from '../../../api/properties/propertyApi'
import BaseModal from '../../common/BaseModal.vue'

const emit = defineEmits(['close', 'deleted'])

const props = defineProps(['image', 'propertyId'])

const deleteImage = async () => {
  await propertyApi.deletePropertyImage(props.propertyId, props.image.id)
  emit('deleted')
  emit('close')
}
</script>
