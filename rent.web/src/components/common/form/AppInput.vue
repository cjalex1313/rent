<template>
  <div>
    <label :for="id" class="block text-sm font-medium leading-6 text-gray-900">
      {{ props.label }}
    </label>
    <div class="mt-2">
      <input
        type="text"
        :name="id"
        :id="id"
        :value="props.modelValue"
        @input="emit('update:modelValue', $event.target.value)"
        class="block w-full rounded-md border-0 py-1.5 px-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
      />
    </div>
    <p v-for="error of props.errors" :key="error.$uid" class="mt-2 text-sm text-red-600">
      {{ error.$message }}
    </p>
  </div>
</template>

<script setup>
const props = defineProps(['label', 'modelValue', 'errors'])
const emit = defineEmits(['update:modelValue'])

const id = Date.now()
</script>
