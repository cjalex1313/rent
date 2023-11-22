import axios from 'axios'
import { useToast } from 'vue-toastification'
import router from '../router/index'

const toast = useToast()

axios.defaults.baseURL = import.meta.env.VITE_API_URL

const instance = axios.create()

instance.interceptors.request.use(function (config) {
  const token = localStorage.getItem('access_token')
  config.headers.Authorization = `Bearer ${token}`
  return config
})

instance.interceptors.response.use(
  function (response) {
    return response
  },
  function (error) {
    if (error.response) {
      if (error.response.status == 401) {
        console.log(router)
        toast.error('Unauthenticated')
        router.push({
          name: 'Login'
        })
      } else if (error.response.data) {
        const errorData = error.response.data
        if (errorData && !errorData.Succeeded) {
          if (errorData.Error) {
            toast.error(errorData.Error)
          }
        }
      }
    }
    return Promise.reject(error)
  }
)

export default instance
