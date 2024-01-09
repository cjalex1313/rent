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
  addPropertyImages: async (propertyId, files) => {
    const formData = new FormData()
    files.forEach((file) => {
      formData.append('images', file)
    })
    const response = await baseApi.post(`/Property/${propertyId}/add-images`, formData, {
      headers: {
        'Content-Type': 'multipart/form-data'
      }
    })
    return response.success
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
  },
  deletePropertyImage: async (propertyId, imageId) => {
    await baseApi.delete(`/Property/${propertyId}/images/${imageId}`)
  },
  makeThumbnail: async (propertyId, imageId) => {
    await baseApi.patch(`/Property/${propertyId}/set-thumbnail`, {
      imageId: imageId
    })
  }
}

export default propertyApi
