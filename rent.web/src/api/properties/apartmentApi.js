import baseApi from '../baseApi'

const apartmentApi = {
  createBasicApartment: async (name, country, city, state, street, postalCode, size, number) => {
    const response = await baseApi.post('/Apartment', {
      name,
      country,
      city,
      state,
      street,
      postalCode,
      size,
      number,
      floor: 0,
      buildingMaxFloor: 0,
      apartmentNumber: 0
    })
    return response.data
  },
  getApartment: async (id) => {
    const response = await baseApi.get(`/Apartment/${id}`)
    return response.data.apartment
  },
  updateApartment: async (apartment) => {
    const response = await baseApi.put('Apartment', apartment)
    return response.data.apartment
  }
}

export default apartmentApi
