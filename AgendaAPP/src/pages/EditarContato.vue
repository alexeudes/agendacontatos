<template>
  <Toast />
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
    <h3>Editar contato</h3>
    <div class="p-card-body">
      <div class="p-fluid p-formgrid p-grid">
        <InputGroup>
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
        <InputGroup>
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
        <InputGroup>
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
        label="Atualizar"
        icon="pi pi-save"
        severity="primary"
        class="mr-2"
        @click="atualizarContato"
        raised
      />
    </div>
  </form>
</template>
<script lang="ts">
import type { Contato } from '@/models/Contato'
import { agendaService } from '@/services/agendaservice'
import { validacoes } from '@/validators/validacao'
import useVuelidate from '@vuelidate/core'
import { useToast } from 'primevue/usetoast'
import { onMounted, reactive } from 'vue'
import { useRouter, useRoute } from 'vue-router'

export default {
  props: [],
  setup(props) {
    const router = useRouter()
    const route = useRoute()
    const state = reactive({
      contato: {
        nome: '',
        email: '',
        telefone: ''
      } as Contato
    })

    const toast = useToast()
    const v$ = useVuelidate(validacoes, state.contato)

    onMounted(() => {
      getContatoById(+route.params.id)
    })

    function getContatoById(idContato: number) {
      agendaService
        .get(`/Agenda/GetById/${idContato}`)
        .then((res) => {
          const contato: Contato = res.data
          state.contato.id = contato.id
          state.contato.nome = contato.nome
          state.contato.email = contato.email
          state.contato.telefone = contato.telefone
        })
        .catch((error: any) => {
          console.error(error)
        })
    }

    async function atualizarContato() {
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
        .put(`/Agenda`, {
          ...state.contato
        })
        .then(() => {
          toast.add({
            life: 4000,
            severity: 'success',
            summary: 'Sucesso!',
            detail: 'Contato atualizado com sucesso!'
          })

          setTimeout(() => {
            voltarPagina()
          }, 2000)
        })
    }

    function voltarPagina() {
      router.back()
    }

    return {
      state,
      voltarPagina,
      atualizarContato,
      v$
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
