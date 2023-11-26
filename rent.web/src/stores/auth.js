import { ref } from 'vue'
import { defineStore } from 'pinia'
import { useRouter } from 'vue-router'
import authApi from '../api/user/authApi'

export const useAuthStore = defineStore('auth', () => {
  const router = useRouter()
  const accessToken = ref('')
  if (localStorage.getItem('access_token')) {
    accessToken.value = localStorage.getItem('access_token')
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

  return { accessToken, login, logout }
})
