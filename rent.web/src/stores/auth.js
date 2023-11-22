import { ref } from 'vue'
import { defineStore } from 'pinia'
import { useRouter } from 'vue-router'
import authApi from '../api/authApi'

export const useAuthStore = defineStore('auth', () => {
  const router = useRouter()
  const accessToken = ref('')
  if(localStorage.getItem('access_token')) {
    accessToken.value = localStorage.getItem('access_token')
  }

  const register = async (username, email, password) => {
    const registerData = await authApi.register(username, email, password)
    if (registerData && registerData.succeeded) {
      router.push({ name: 'Login' })
    }
  }

  const login = async (username, password) => {
    const loginData = await authApi.login(username, password)
    if (loginData.succeeded) {
      accessToken.value = loginData.token
      localStorage.setItem('access_token', accessToken.value)
      router.push({ name: 'home' })
    }
  }

  const logout = () => {
    accessToken.value = ''
    if (localStorage.getItem('access_token')) {
      localStorage.removeItem('access_token')
    }
    router.push({ name: 'Login' })
  }

  return { accessToken, register, login, logout }
})
