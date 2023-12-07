import { reactive } from 'vue'
import { defineStore } from 'pinia'
import userDetailApi from '../api/user/userDetailApi'

export const useUserDetailsStore = defineStore('userDetails', () => {
  const userDetails = reactive({
    firstName: null,
    lastName: null,
    avatarUrl: null
  })

  async function loadUserDetails() {
    const details = await userDetailApi.getUserDetail()
    userDetails.firstName = details.firstName
    userDetails.lastName = details.lastName
    userDetails.avatarUrl = details.avatarUrl
  }

  return { userDetails, loadUserDetails }
})
