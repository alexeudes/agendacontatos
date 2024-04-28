<script setup lang="ts">
import { ref } from 'vue'
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import ColumnGroup from 'primevue/columngroup'
import Row from 'primevue/row'
import Toolbar from 'primevue/toolbar'
import Button from 'primevue/button'
import IconField from 'primevue/iconfield'
import InputIcon from 'primevue/inputicon'
import InputText from 'primevue/inputtext'
import Dialog from 'primevue/dialog'

import { Contato } from 'models/Contato'

const items: Contato = ref([
  {
    id: 1,
    nome: 'Alex',
    email: 'alex@gmail.com',
    telefone: '99999-9999'
  },
  {
    id: 2,
    nome: 'Eudes',
    email: 'eudes@gmail.com',
    telefone: '98888-8888'
  }
])

const visibleCadastroDialog = ref(false)
const visibleEdicaoDialog = ref(false)

const contatoModel: Contato = defineModel()

const salvarContato = (contato: Contato) => {
  if (contato != null) {
    items.value.push(contato.value)
    visibleCadastroDialog = false
  }
}
</script>

<template>
  <div class="wrapper">
    <Toolbar class="mb-4">
      <template #start>
        <Button
          label="New"
          icon="pi pi-plus"
          severity="success"
          class="mr-2"
          @click="visibleCadastroDialog = true"
        />
        <!--<Button
          label="Delete"
          icon="pi pi-trash"
          severity="danger"
          @click="confirmDeleteSelected"
        />-->
      </template>
    </Toolbar>
  </div>

  <DataTable :value="items" :rows="10" tableStyle="min-width: 50rem">
    <template #header>
      <div class="flex flex-wrap gap-2 align-items-center justify-content-between">
        <h4 class="m-0">Contatos</h4>
        <IconField iconPosition="left">
          <InputIcon>
            <i class="pi pi-search" />
          </InputIcon>
          <InputText placeholder="Buscar..." />
        </IconField>
      </div>
    </template>
    <!--<Column selectionMode="multiple" style="width: 3rem" :exportable="false"></Column>-->
    <Column field="id" header="Código" style="min-width: 12rem"></Column>
    <Column field="nome" header="Nome" style="min-width: 16rem"></Column>
    <Column field="email" header="E-mail" style="min-width: 10rem"></Column>
    <Column field="telefone" header="Telefone" style="min-width: 10rem"></Column>
    <Column :exportable="false" style="min-width: 8rem">
      <template #body="slotProps">
        <Button
          icon="pi pi-pencil"
          outlined
          rounded
          class="mr-2"
          @click="visibleEdicaoDialog = true"
        />
        <Button
          icon="pi pi-trash"
          outlined
          rounded
          severity="danger"
          @click="confirmDeleteProduct(slotProps.data)"
        />
      </template>
    </Column>
  </DataTable>

  <!-- Modal de Cadastro -->
  <Dialog
    ref="contatoModel"
    v-model:visible="visibleCadastroDialog"
    modal
    header="Cadastrar Contato"
    :style="{ width: '25rem' }"
  >
    <span class="p-text-secondary block mb-5">Informe os dados do contato.</span>
    <div class="flex align-items-center gap-3 mb-5">
      <label for="username" class="font-semibold w-6rem">Nome: </label>
      <InputText v-model="value" id="nome" class="flex-auto" autocomplete="off" />
    </div>
    <div class="flex align-items-center gap-3 mb-5">
      <label for="email" class="font-semibold w-6rem">E-mail: </label>
      <InputText v-model="value" id="email" class="flex-auto" autocomplete="off" />
    </div>
    <div class="flex align-items-center gap-3 mb-5">
      <label for="telefone" class="font-semibold w-6rem">Telefone: </label>
      <InputText v-model="value" id="telefone" class="flex-auto" autocomplete="off" />
    </div>
    <div class="flex justify-content-end gap-2">
      <Button
        type="button"
        label="Cancelar"
        severity="secondary"
        @click="visibleCadastroDialog = false"
      ></Button>
      <Button type="button" label="Salvar" @click="salvarContato"></Button>
    </div>
  </Dialog>

  <!-- Modal de Edição -->
  <Dialog
    v-model:visible="visibleEdicaoDialog"
    modal
    header="Editar Contato"
    :style="{ width: '25rem' }"
  >
    <span class="p-text-secondary block mb-5">Atualize as informações do contato.</span>
    <div class="flex align-items-center gap-3 mb-5">
      <label for="username" class="font-semibold w-6rem">Nome: </label>
      <InputText id="nome" class="flex-auto" autocomplete="off" />
    </div>
    <div class="flex align-items-center gap-3 mb-5">
      <label for="email" class="font-semibold w-6rem">E-mail: </label>
      <InputText id="email" class="flex-auto" autocomplete="off" />
    </div>
    <div class="flex align-items-center gap-3 mb-5">
      <label for="email" class="font-semibold w-6rem">Telefone: </label>
      <InputText id="email" class="flex-auto" autocomplete="off" />
    </div>
    <div class="flex justify-content-end gap-2">
      <Button
        type="button"
        label="Cancelar"
        severity="secondary"
        @click="visibleEdicaoDialog = false"
      ></Button>
      <Button type="button" label="Atualizar" @click="visibleEdicaoDialog = false"></Button>
    </div>
  </Dialog>
</template>

<style scoped></style>
