<template>
  <button
    type="button"
    class="rounded-lg bg-indigo-600 m-3 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
  >
    {{ props.text }}
  </button>
</template>

<script setup>
const props = defineProps(['text'])
</script>
