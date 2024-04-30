<template>
  <Toast />
  <div>
    <div class="card">
      <Toolbar />
      <DataTable
        :filters="filters"
        :value="state.contatos"
        :rows="15"
        dataKey="id"
        tableStyle="min-width: 50rem"
        filterDisplay="menu"
        :globalFilterFields="['nome']"
      >
        <template #header>
          <div class="flex flex-wrap align-items-center justify-content-between">
            <h4 class="m-0">Meus Contatos</h4>
            <IconField iconPosition="left">
              <InputIcon>
                <i class="pi pi-search" />
              </InputIcon>
              <InputText placeholder="Buscar..." />
            </IconField>
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
              @click="editarContato(slotProps.data)"
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
    </div>
  </div>

  <DialogModal
    :visible="dialogExclusaoVisible"
    @closeModal="closeModalExclusao"
    @excluirContato="excluirContato"
  />
</template>

<script lang="ts">
import { onMounted, reactive, ref } from 'vue'
import Toolbar from './Toolbar.vue'
import DialogModal from './DialogModal.vue'
import type { Contato } from '@/models/Contato'
import { agendaService } from '@/services/agendaservice'
import { useToast } from 'primevue/usetoast'
import { FilterMatchMode, FilterOperator } from 'primevue/api'

export default {
  props: ['items', ''],
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
      contatos: [] as Contato[],
      searchText: ''
    })

    const toast = useToast()
    const filters = ref()

    onMounted(() => {
      getContatos()
    })

    function initFilters() {
      filters.value = {
        nome: {
          operator: FilterOperator.AND,
          constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }]
        }
      }
    }

    initFilters()

    function getContatos(isDelete: boolean = false) {
      agendaService
        .get('/Agenda')
        .then((res) => {
          state.contatos = res.data
          toast.add({
            life: 4000,
            severity: isDelete ? 'info' : 'success',
            summary: 'Sucesso!',
            detail: 'Contatos carregados com sucesso.'
          })
        })
        .catch(() => {
          toast.add({
            life: 4000,
            severity: 'error',
            summary: 'Erro!',
            detail: 'Não foi possível carregar a lista de contatos.'
          })
        })
    }

    return {
      state,
      getContatos,
      toast,
      filters
    }
  },
  data() {
    return {
      dialogExclusaoVisible: false,
      contatoSelecionado: {} as Contato
    }
  },
  methods: {
    showModalExclusao(contato: Contato) {
      this.contatoSelecionado = contato
      this.dialogExclusaoVisible = true
    },
    closeModalExclusao() {
      this.dialogExclusaoVisible = false
    },
    editarContato(contato: Contato) {
      this.$router.push({ name: 'editar', params: { id: contato.id } })
    },
    excluirContato() {
      if (this.contatoSelecionado != null) {
        const contatoIndex = this.state.contatos.findIndex((c) => c == this.contatoSelecionado)
        this.state.contatos.splice(contatoIndex, 1)
        this.deletarContato(this.contatoSelecionado.id)
      }
      this.closeModalExclusao()
    },
    async deletarContato(idContato: number) {
      agendaService.delete(`/Agenda/${idContato}`).then((res) => {
        this.toast.add({
          life: 4000,
          severity: 'success',
          summary: 'Sucesso!',
          detail: 'Contatos excluído com sucesso.'
        })

        setTimeout(() => {
          this.getContatos(true)
        }, 2000)
      })
    }
  },
  computed: {
    filterContatos() {
      const normalizedSearch = this.state.searchText.toLowerCase().trim()
      return this.state.contatos.filter((contato) => {
        contato.nome.toLocaleLowerCase().includes(normalizedSearch)
      })
    }
  }
}
</script>
<style scoped>
.card {
  background: var(--surface-card);
  padding: 2rem;
  border-radius: 10px;
  margin-bottom: 1rem;
}
</style>
