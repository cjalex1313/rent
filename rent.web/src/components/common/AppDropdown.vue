<template>
  <div class="inline-block relative">
    <slot :toggleShow="toggleShow" name="trigger">
      <button @click.stop="toggleShow()">
        {{ props.text }}
      </button>
    </slot>
    <div
      v-if="showMenu"
      :class="{
        'right-0': props.orientation == 'right',
        'left-0': props.orientation == 'left'
      }"
      class="absolute z-10 mt-2 w-48 rounded-md bg-white py-1 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
      role="menu"
      aria-orientation="vertical"
      aria-labelledby="user-menu-button"
      tabindex="-1"
    >
      <slot name="menu">
        <!-- Active: "bg-gray-100", Not Active: "" -->
        <a
          href="#"
          class="block px-4 py-2 text-sm text-gray-700"
          role="menuitem"
          tabindex="-1"
          id="user-menu-item-0"
        >
          Test
        </a>
      </slot>
    </div>
  </div>
</template>

<script setup>
import { onMounted, onUnmounted, ref } from 'vue'

const props = defineProps({
  text: {
    type: String,
    default: ''
  },
  orientation: {
    type: String,
    default: 'left'
  }
})

const showMenu = ref(false)

const toggleShow = () => {
  showMenu.value = !showMenu.value
}

const close = () => {
  showMenu.value = false
}

onMounted(() => {
  document.addEventListener('click', close)
})
onUnmounted(() => {
  document.removeEventListener('click', close)
})
</script>
