<script setup lang="ts">
import Toolbar from 'primevue/toolbar'
import Button from 'primevue/button'
import IconField from 'primevue/iconfield'
import InputIcon from 'primevue/inputicon'
import InputText from 'primevue/inputtext'

const props = defineProps({
  searchText: {
    type: String,
    required: false
  }
})
</script>

<template>
  <Toolbar class="mb-4">
    <template #start>
      <Button
        label="Novo contato"
        icon="pi pi-plus"
        severity="success"
        class="mr-2"
        @click="$router.push('new')"
      />
    </template>

    <!-- <template #end>
      <IconField iconPosition="left">
        <InputIcon>
          <i class="pi pi-search" />
        </InputIcon>
        <InputText :v-model="searchText" placeholder="Buscar..." />
      </IconField>
    </template> -->
  </Toolbar>
</template>
