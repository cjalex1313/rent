<template>
  <section class="bg-gray-50 min-h-screen">
    <div class="flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0">
      <router-link to="/" class="flex items-center mb-6 text-2xl font-semibold text-gray-900">
        Home
      </router-link>
      <div class="w-full bg-white rounded-lg shadow md:mt-0 sm:max-w-md xl:p-0">
        <div v-if="success" class="p-6 space-y-4 md:space-y-6 sm:p-8">
          <h1
            class="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl text-center"
          >
            Your account has been activated
          </h1>
          <div>
            <button
              @click="goToLogin()"
              type="button"
              class="w-full text-white bg-blue-600 hover:bg-blue-700 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
            >
              Login
            </button>
          </div>
        </div>
        <div v-if="error" class="p-6 space-y-4 md:space-y-6 sm:p-8">
          <h1
            class="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl text-center"
          >
            Something went wrong
          </h1>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import authApi from '../../api/authApi'

const success = ref(false)
const error = ref(false)
const route = useRoute()
const router = useRouter()

const goToLogin = () => {
  router.push({
    name: 'Login'
  })
}

const confirm = async () => {
  const confirmationSuccess =
    (await authApi.confirmEmail(route.query.userId, route.query.token)) ?? false
  success.value = confirmationSuccess
}

if (!route.query.userId || !route.query.token) {
  error.value = true
} else {
  confirm()
}
</script>
