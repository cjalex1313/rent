<template>
  <div>
    <div v-if="apartment">
      <ApartmentForm
        @save-apartment="saveApartment"
        :apartment="apartment"
        class="p-4"
      />
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRoute } from 'vue-router'
import apartmentApi from '../../api/properties/apartmentApi'
import ApartmentForm from '../../components/property/apartment/ApartmentForm.vue';

const route = useRoute()
const apartmentId = route.params.id
const apartment = ref(null)

const loadApartment = async () => {
  apartment.value = await apartmentApi.getApartment(apartmentId)
}

const saveApartment = async () => {
  apartment.value = await apartmentApi.updateApartment(apartment.value)
}

loadApartment()
</script>
