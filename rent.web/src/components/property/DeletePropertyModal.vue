<template>
  <BaseModal @close="emit('close')" title="Delete property">
    <template #body>
      <p class="mt-1 text-sm leading-6 text-gray-600">
        Are you sure you want to delete {{ props.property.name }}
      </p>
    </template>
    <template #footer>
      <div class="mt-3 sm:flex sm:flex-row-reverse">
        <button
          @click="deleteProperty()"
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
import BaseModal from '../common/BaseModal.vue'
import propertyApi from '../../api/properties/propertyApi';


const props = defineProps(['property'])
const emit = defineEmits(['close', 'success'])

const deleteProperty = async () => {
  await propertyApi.deleteProperty(props.property.id)
  emit('success')
}
</script>
