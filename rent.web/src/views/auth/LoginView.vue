<template>
  <section class="bg-gray-50 min-h-screen">
    <div class="flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0">
      <div class="w-full bg-white rounded-lg shadow md:mt-0 sm:max-w-md xl:p-0">
        <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
          <h1 class="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl">
            Sign in to your account
          </h1>
          <form class="space-y-4 md:space-y-6" action="#">
            <div>
              <label for="username" class="block mb-2 text-sm font-medium text-gray-900">
                Username
              </label>
              <input
                v-model="loginState.username"
                name="username"
                id="username"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                placeholder="username"
                required
              />
              <p
                v-for="error of v$.username.$errors"
                :key="error.$uid"
                class="mt-2 text-sm text-red-600"
              >
                {{ error.$message }}
              </p>
            </div>
            <div>
              <label for="password" class="block mb-2 text-sm font-medium text-gray-900">
                Password
              </label>
              <input
                v-model="loginState.password"
                v-on:keyup.enter="login()"
                type="password"
                name="password"
                id="password"
                placeholder="••••••••"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                required
              />
              <p
                v-for="error of v$.password.$errors"
                :key="error.$uid"
                class="mt-2 text-sm text-red-600"
              >
                {{ error.$message }}
              </p>
            </div>
            <div class="flex items-center justify-between"></div>
            <button
              @click="login()"
              type="button"
              class="w-full text-white bg-blue-600 hover:bg-blue-700 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
            >
              Sign in
            </button>
            <p class="text-sm font-light text-gray-500">
              Don’t have an account yet?
              <router-link to="/auth/register" class="font-medium text-primary-600 hover:underline">
                Sign up
              </router-link>
            </p>
          </form>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
import useVuelidate from '@vuelidate/core'
import { helpers, required } from '@vuelidate/validators'
import { reactive } from 'vue'
import { useAuthStore } from '../../stores/auth'

const loginState = reactive({
  username: '',
  password: ''
})

const authState = useAuthStore()

const rules = {
  username: { required: helpers.withMessage('Username is required', required) },
  password: { required: helpers.withMessage('Password is required', required) }
}

const v$ = useVuelidate(rules, loginState)

authState.logout()

const login = async () => {
  v$.value.$touch()
  const isValid = await v$.value.$validate()
  if (!isValid) return
  await authState.login(loginState.username, loginState.password)
}
</script>
