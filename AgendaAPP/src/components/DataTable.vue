<template>
  <Toolbar @novoContato="showModalCadastro"></Toolbar>

  <DataTable :value="state.items" :rows="10" tableStyle="min-width: 50rem">
    <template #header>
      <div class="flex flex-wrap gap-2 align-items-center justify-content-between">
        <h4 class="m-0">Meus Contatos</h4>
      </div>
    </template>

    <Column
      v-for="col of state.columns"
      :key="col.field"
      :field="col.field"
      :header="col.header"
      :style="col.style"
    ></Column>
    <Column :exportable="false" style="min-width: 8rem">
      <template #body="slotProps">
        <Button
          icon="pi pi-pencil"
          outlined
          rounded
          class="mr-2"
          @click="showModalEdicao(slotProps.data)"
        />
        <Button
          icon="pi pi-trash"
          outlined
          rounded
          severity="danger"
          @click="showModalExclusao(slotProps.data)"
        />
      </template>
    </Column>
  </DataTable>

  <DialogModal
    :visible="dialogCadastroVisible"
    :header="headerDialogCadastro"
    :description="'Informe os dados de cadastro do usuário'"
    :isExclusao="false"
    @closeModal="closeModalCadastro"
  ></DialogModal>

  <DialogModal
    :visible="dialogEdicaoVisible"
    :header="headerDialogEdicao"
    :description="'Atualize as informações do usuário'"
    :isExclusao="false"
    :objContato="state.contato"
    @closeModal="closeModalEdicao"
  ></DialogModal>

  <DialogModal
    :visible="dialogExclusaoVisible"
    :header="headerDialogExclusao"
    :description="'Deseja mesmo excluir este contato?'"
    :isExclusao="true"
    :objContato="state.contato"
    @closeModal="closeModalExclusao"
  ></DialogModal>
</template>

<script lang="ts">
import { reactive } from 'vue'
import Toolbar from './Toolbar.vue'
import DialogModal from './DialogModal.vue'
import type { Contato } from '@/models/Contato'

export default {
  props: ['items', 'contato'],
  components: {
    Toolbar,
    DialogModal
  },
  setup(props) {
    const state = reactive({
      columns: [
        {
          field: 'id',
          header: 'Código',
          style: 'min-width: 12rem'
        },
        {
          field: 'nome',
          header: 'Nome',
          style: 'min-width: 16rem'
        },
        {
          field: 'email',
          header: 'E-mail',
          style: 'min-width: 10rem'
        },
        {
          field: 'telefone',
          header: 'Telefone',
          style: 'min-width: 10rem'
        }
      ],
      items: [
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
      ],
      contato: {} as Contato
    })

    return {
      state
    }
  },
  data() {
    return {
      dialogCadastroVisible: false,
      dialogEdicaoVisible: false,
      dialogExclusaoVisible: false,
      headerDialogCadastro: 'Cadastrar contato',
      headerDialogEdicao: 'Editar contato',
      headerDialogExclusao: 'Excluir contato'
    }
  },
  methods: {
    showModalCadastro() {
      this.dialogCadastroVisible = true
    },
    closeModalCadastro() {
      this.dialogCadastroVisible = false
    },
    showModalEdicao(contato: Contato) {
      this.state.contato = contato
      this.dialogEdicaoVisible = true
    },
    closeModalEdicao() {
      this.state.contato = {} as Contato
      this.dialogEdicaoVisible = false
    },
    showModalExclusao(contato: Contato) {
      this.state.contato = contato
      this.dialogExclusaoVisible = true
    },
    closeModalExclusao() {
      this.state.contato = {} as Contato
      this.dialogExclusaoVisible = false
    }
  }
}
</script>
