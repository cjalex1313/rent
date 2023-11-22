<template>
  <section class="bg-gray-50 min-h-screen">
    <div class="flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0">
      <router-link
        to="/"
        class="flex items-center mb-6 text-2xl font-semibold text-gray-900"
      >
        Home
      </router-link>
      <div
        class="w-full bg-white rounded-lg shadow md:mt-0 sm:max-w-md xl:p-0"
      >
        <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
          <h1
            class="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl"
          >
            Sign up for Rent
          </h1>
          <form class="space-y-4 md:space-y-6" action="#">
            <div>
              <label
                for="username"
                class="block mb-2 text-sm font-medium text-gray-900"
              >
                Username
              </label>
              <input
                v-model="registerState.username"
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
              <label
                for="email"
                class="block mb-2 text-sm font-medium text-gray-900"
              >
                Email
              </label>
              <input
                v-model="registerState.email"
                type="email"
                name="email"
                id="email"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                placeholder="email@example.com"
                required
              />
              <p
                v-for="error of v$.email.$errors"
                :key="error.$uid"
                class="mt-2 text-sm text-red-600"
              >
                {{ error.$message }}
              </p>
            </div>
            <div>
              <label
                for="password"
                class="block mb-2 text-sm font-medium text-gray-900"
              >
                Password
              </label>
              <input
                v-model="registerState.password"
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
            <div>
              <label
                for="password"
                class="block mb-2 text-sm font-medium text-gray-900"
              >
                Password check
              </label>
              <input
                v-model="registerState.passwordCheck"
                type="password"
                name="password-check"
                id="password-check"
                placeholder="••••••••"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                required
              />
              <p
                v-for="error of v$.passwordCheck.$errors"
                :key="error.$uid"
                class="mt-2 text-sm text-red-600"
              >
                {{ error.$message }}
              </p>
            </div>
            <button
              @click="register()"
              type="button"
              class="w-full text-white bg-blue-600 hover:bg-blue-700 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
            >
              Sign in
            </button>
            <p class="text-sm font-light text-gray-500">
              Already have an account?
              <router-link
                to="/auth/login"
                class="font-medium text-primary-600 hover:underline"
              >
                Sign in
              </router-link>
            </p>
          </form>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
import { reactive, computed } from 'vue'
import { useVuelidate } from '@vuelidate/core'
import { required, email, sameAs, helpers } from '@vuelidate/validators'
import { useAuthStore } from '../../stores/auth'

const registerState = reactive({
  username: '',
  email: '',
  password: '',
  passwordCheck: ''
})

const authState = useAuthStore()

const passwordRef = computed(() => registerState.password)

const rules = {
  username: { required: helpers.withMessage('Username is required', required) },
  email: {
    required: helpers.withMessage('Email is required', required),
    email: helpers.withMessage('Provided email is not valid', email)
  },
  password: {
    required: helpers.withMessage('Password is required', required),
    uppercase: helpers.withMessage(
      'Password must contain at least one uppercase letter',
      (value) => {
        return /[A-Z]/.test(value)
      }
    ),
    lowercase: helpers.withMessage(
      'Password must contain at least one lowercase letter',
      (value) => {
        return /[a-z]/.test(value)
      }
    ),
    digit: helpers.withMessage('Passowrd must contain at least one digit', (value) => {
      return /[0-9]/.test(value)
    }),
    special: helpers.withMessage(
      'Passowrd must contain at least one special character',
      (value) => {
        return /[#?!@$%^&*-]/.test(value)
      }
    )
  },
  passwordCheck: {
    required: helpers.withMessage('Password check is required', required),
    sameAs: helpers.withMessage('Passwords do not match', sameAs(passwordRef))
  }
}

const v$ = useVuelidate(rules, registerState)

const register = async () => {
  v$.value.$touch()
  const isValid = await v$.value.$validate()
  if (!isValid) return
  await authState.register(registerState.username, registerState.email, registerState.password)
}
</script>
