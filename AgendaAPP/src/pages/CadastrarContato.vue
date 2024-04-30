<template>
  <Toast />
  <main>
    <header>
      <Button
        type="button"
        label="Voltar"
        icon="pi pi-arrow-left"
        severity="secondary"
        class="mr-2"
        @click="voltarPagina"
        raised
      />
    </header>
    <form class="p-card p-shadow-4">
      <h3>Cadastrar contato</h3>
      <div class="p-card-body">
        <div class="p-fluid p-formgrid p-grid">
          <InputGroup class="p-field p-col">
            <InputGroupAddon>
              <i class="pi pi-user"></i>
            </InputGroupAddon>
            <InputText
              v-model="state.contato.nome"
              id="nome"
              class="flex-auto"
              autocomplete="off"
              placeholder="Informe o nome"
            />
          </InputGroup>
        </div>
        <div class="p-fluid p-formgrid p-grid">
          <InputGroup class="p-field p-col">
            <InputGroupAddon>
              <i class="pi pi-inbox"></i>
            </InputGroupAddon>
            <InputText
              v-model="state.contato.email"
              id="email"
              class="flex-auto"
              autocomplete="off"
              placeholder="email@email.com"
            />
          </InputGroup>
        </div>
        <div class="p-fluid p-formgrid p-grid">
          <InputGroup class="p-field p-col">
            <InputGroupAddon>
              <i class="pi pi-phone"></i>
            </InputGroupAddon>
            <InputMask
              v-model="state.contato.telefone"
              id="telefone"
              mask="(99) 99999-9999"
              placeholder="(99) 99999-9999"
              class="flex-auto"
              autocomplete="off"
            />
          </InputGroup>
        </div>
        <Button
          type="button"
          label="Salvar"
          icon="pi pi-save"
          severity="primary"
          class="mr-2"
          @click="salvarContato"
          raised
        />
      </div>
    </form>
  </main>
</template>
<script lang="ts">
import type { Contato } from '@/models/Contato'
import { agendaService } from '@/services/agendaservice'
import { validacoes } from '@/validators/validacao'
import useVuelidate from '@vuelidate/core'
import { useToast } from 'primevue/usetoast'
import { reactive } from 'vue'
import { useRouter } from 'vue-router'

export default {
  props: [],
  setup(props) {
    const router = useRouter()
    const state = reactive({
      contato: {
        nome: '',
        email: '',
        telefone: ''
      } as Contato
    })

    const toast = useToast()

    async function salvarContato() {
      const contatoValido = await v$.value.$validate()

      if (!contatoValido) {
        let erroMsg = ''
        if (v$.value.nome.$errors.length > 0) {
          erroMsg = v$.value.nome.$errors[0].$message.toString()
        } else if (v$.value.email.$errors.length > 0) {
          erroMsg = v$.value.email.$errors[0].$message.toString()
        } else if (v$.value.telefone.$errors.length > 0) {
          erroMsg = v$.value.telefone.$errors[0].$message.toString()
        }

        toast.add({
          life: 4000,
          severity: 'error',
          summary: 'Erro no preenchimento do formulário',
          detail: erroMsg
        })

        return
      }

      agendaService
        .post('/Agenda', { ...state.contato })
        .then((res) => {
          toast.add({
            life: 4000,
            severity: 'success',
            summary: 'Sucesso!',
            detail: 'Salvo com sucesso!'
          })

          setTimeout(() => {
            router.back()
          }, 2000)
        })
        .catch((error: any) => {
          toast.add({
            life: 4000,
            severity: 'error',
            summary: 'Falha!',
            detail: 'Ocorreu um erro ao tentar salvar o contato!'
          })
        })
    }

    function voltarPagina() {
      router.back()
    }

    const v$ = useVuelidate(validacoes, state.contato)

    return {
      state,
      voltarPagina,
      salvarContato,
      v$
    }
  },
  data() {
    return {
      contato: {
        nome: '',
        email: '',
        telefone: ''
      } as Contato
    }
  },
  validations() {
    return {
      contato: {
        nome: '',
        email: '',
        telefone: ''
      } as Contato
    }
  }
}
</script>
<style scoped>
.p-card {
  width: 500px;
  margin: auto;
}

.p-card-body {
  padding: 1rem;
}

form h3 {
  align-items: center;
  justify-content: center;
  display: flex;
}
</style>
