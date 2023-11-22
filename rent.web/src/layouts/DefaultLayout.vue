<template>
  <div>
    <NavBar />
    <RouterView class="px-2 lg:px-7 xl:px-10" />
  </div>
</template>

<script setup>
import NavBar from '../components/common/NavBar.vue'
</script>
