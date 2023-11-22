import baseApi from '../baseApi'

const houseApi = {
  createBasicHouse: async (name, country, city, state, street, postalCode, size, number) => {
    const response = await baseApi.post('/House', {
      name,
      country,
      city,
      state,
      street,
      postalCode,
      size,
      number,
      landSize: 0,
      levels: 0
    })
    return response.data
  },
  getHouse: async (id) => {
    const response = await baseApi.get(`/House/${id}`)
    return response.data.house
  },
  updateHouse: async (house) => {
    const response = await baseApi.put('House', house)
    return response.data.house
  }
}

export default houseApi
