<template>
  <Toast />
  <main>
    <header>
      <h3>Cadastrar contato</h3>
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
    <form>
      <div class="flex align-items-center gap-4 mb-4">
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
      <div class="flex align-items-center gap-4 mb-4">
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
      <div class="flex align-items-center gap-4 mb-4">
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
        label="Salvar"
        icon="pi pi-save"
        severity="primary"
        class="mr-2"
        @click="salvarContato"
        raised
      />
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
/*
* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

header {
  width: 100%;
  max-width: calc(800px * 0.9);
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: left;
}

main {
  width: 100%;
  height: 90vh;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 20px;
}

main h1 {
  font-size: 1.6rem;
}

form {
  display: flex;
  flex-direction: column;
  width: 90%;
  max-width: calc(800px * 0.9);
  gap: 8px;
}

 .container {
  width: 440px;
  padding: 40px 32px;
  border-radius: 8px;
  box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px;
} */
</style>
