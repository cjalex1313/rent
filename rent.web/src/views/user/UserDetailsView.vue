<template>
  <div>
    <div class="border-b border-gray-900/10 pb-12">
      <h2 class="text-base font-semibold leading-7 text-gray-900">Personal Information</h2>
      <p class="mt-1 text-sm leading-6 text-gray-600">Information about yourself.</p>

      <div class="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
        <div class="sm:col-span-3">
          <label for="first-name" class="block text-sm font-medium leading-6 text-gray-900">
            First name
          </label>
          <div class="mt-2">
            <input
              v-model="userDetails.firstName"
              type="text"
              name="first-name"
              id="first-name"
              autocomplete="given-name"
              class="block w-full rounded-md border-0 py-1.5 px-1 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
            />
          </div>
        </div>

        <div class="sm:col-span-3">
          <label for="last-name" class="block text-sm font-medium leading-6 text-gray-900">
            Last name
          </label>
          <div class="mt-2">
            <input
              v-model="userDetails.lastName"
              type="text"
              name="last-name"
              id="last-name"
              autocomplete="family-name"
              class="block w-full rounded-md border-0 py-1.5 px-1 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
            />
          </div>
        </div>
        <div class="col-span-full">
          <label for="photo" class="block text-sm font-medium leading-6 text-gray-900">Photo</label>
          <div class="mt-2 flex items-center gap-x-3">
            <img
              v-if="userDetails.avatarUrl"
              class="h-12 w-12 rounded-full"
              :src="userDetails.avatarUrl"
            />
            <svg
              v-else
              class="h-12 w-12 text-gray-300"
              viewBox="0 0 24 24"
              fill="currentColor"
              aria-hidden="true"
            >
              <path
                fill-rule="evenodd"
                d="M18.685 19.097A9.723 9.723 0 0021.75 12c0-5.385-4.365-9.75-9.75-9.75S2.25 6.615 2.25 12a9.723 9.723 0 003.065 7.097A9.716 9.716 0 0012 21.75a9.716 9.716 0 006.685-2.653zm-12.54-1.285A7.486 7.486 0 0112 15a7.486 7.486 0 015.855 2.812A8.224 8.224 0 0112 20.25a8.224 8.224 0 01-5.855-2.438zM15.75 9a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0z"
                clip-rule="evenodd"
              />
            </svg>
            <button
              @click="changePhoto"
              type="button"
              class="rounded-md bg-white px-2.5 py-1.5 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
            >
              Change
            </button>
          </div>
        </div>
      </div>
    </div>
    <div class="mt-6 flex items-center justify-end gap-x-6">
      <button
        @click="saveDetails"
        type="button"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        Save
      </button>
    </div>
  </div>
</template>

<script setup>
import { reactive, onBeforeMount, ref } from 'vue'
import { useRouter } from 'vue-router'
import filePrompt from '../../helpers/filePrompt'
import { useUserDetailsStore } from '../../stores/userDatails'
import userDetailApi from '../../api/user/userDetailApi'

const router = useRouter()

const userDetailsStore = useUserDetailsStore()

const userDetails = reactive({
  firstName: '',
  lastName: '',
  avatarUrl: ''
})

const tempFile = ref(null)

onBeforeMount(async () => {
  await userDetailsStore.loadUserDetails()
  userDetails.firstName = userDetailsStore.userDetails.firstName
  userDetails.lastName = userDetailsStore.userDetails.lastName
  userDetails.avatarUrl = userDetailsStore.userDetails.avatarUrl
})

const saveDetails = async () => {
  await Promise.all([
    userDetailApi.setUserDetail({
      firstName: userDetails.firstName,
      lastName: userDetails.lastName
    }),
    (async () => {
      alert(0)
      if (!tempFile.value) return
      alert(1)
      await userDetailApi.setUserAvatar(tempFile.value)
    })()
  ])
  await userDetailsStore.loadUserDetails()
  router.push('/')
}

const changePhoto = () => {
  filePrompt('.png, .jpg, .jpeg', false).then((file) => {
    let fileSize = file.size / 1024 / 1024
    if (fileSize > 2) {
      alert('File size must be less than 2MB')
      return
    }
    tempFile.value = file
    userDetails.avatarUrl = URL.createObjectURL(file)
  })
}
</script>
