import baseApi from '../baseApi'

const authApi = {
  register: async (username, email, password) => {
    const response = await baseApi.post('/Authentication/Register', {
      username,
      email,
      password
    })
    return response.data
  },
  login: async (username, password) => {
    const response = await baseApi.post('/Authentication/Login', {
      username,
      password
    })
    return response.data
  },
  confirmEmail: async (userId, token) => {
    const response = await baseApi.post('/Authentication/Confirmation', {
      userId,
      token
    })
    return response.data.succeeded
  }
}

export default authApi
