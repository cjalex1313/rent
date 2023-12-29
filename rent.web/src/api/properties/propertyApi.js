import baseApi from '../baseApi'

const propertyApi = {
  getUserProperties: async () => {
    const response = await baseApi.get('/Property')
    return response.data.properties
  },

  deleteProperty: async (propId) => {
    await baseApi.delete(`/Property/${propId}`)
  },
  getPropertyIamges: async (propId) => {
    const response = await baseApi.get(`/Property/${propId}/images`)
    return response.data.images
  },
  search: async (country, city, state, page) => {
    const response = await baseApi.get('/Property/search', {
      params: {
        country,
        city,
        state,
        page,
        pageSize: 20
      }
    })
    return response.data
  }
}

export default propertyApi
