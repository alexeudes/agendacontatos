<script setup lang="ts">
import Toolbar from 'primevue/toolbar'
import Button from 'primevue/button'

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
      <Button label="Novo" icon="pi pi-plus" severity="success" @click="$router.push('new')" />
    </template>

    <template #center>
      <h4 class="m-0">Meus Contatos</h4>
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
