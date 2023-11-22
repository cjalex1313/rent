<template>
  <div>
    <div v-if="house">
      <HouseForm @save-house="saveHouse" :house="house" class="p-4" />
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRoute } from 'vue-router'
import houseApi from '../../api/properties/houseApi'
import HouseForm from '../../components/property/house/HouseForm.vue'

const route = useRoute()
const houseId = route.params.id
const house = ref(null)

const loadHouse = async () => {
  house.value = await houseApi.getHouse(houseId)
}

const saveHouse = async () => {
  house.value = await houseApi.updateHouse(house.value)
}

loadHouse()
</script>
