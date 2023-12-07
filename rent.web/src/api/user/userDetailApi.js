import baseApi from '../baseApi'

const userDetailApi = {
  getUserDetail: async () => {
    const response = await baseApi.get('/UserDetail')
    return response.data
  },
  setUserDetail: async (userDetail) => {
    const response = await baseApi.post('/UserDetail', {
      firstName: userDetail?.firstName,
      lastName: userDetail?.lastName
    })
    return response.data
  },
  setUserAvatar: async (file) => {
    const formData = new FormData()
    formData.append('avatar', file)
    const response = await baseApi.post('/UserDetail/avatar', formData, {
      headers: {
        'Content-Type': 'multipart/form-data'
      }
    })
    return response.data
  }
}

export default userDetailApi
