<script setup lang="ts">
import Dialog from 'primevue/dialog'
import Button from 'primevue/button'
import InputText from 'primevue/inputtext'
import type { Contato } from '@/models/Contato'

const props = defineProps({
  visible: {
    type: Boolean,
    required: true
  },
  header: {
    type: String,
    required: true
  },
  style: {
    type: String,
    default: '{ width: "25rem" }'
  },
  description: {
    type: String,
    required: true
  },
  isExclusao: {
    type: Boolean,
    required: true
  },
  objContato: {
    type: Object
  }
})

const salvarContato = (contato: Contato) => {
  if (contato != null) {
    // items.value.push(contato.value)
    //visibleCadastroDialog = false
  }
}
</script>

<template>
  <Dialog :visible="visible" modal :header="header" :style="style">
    <span class="p-text-secondary block mb-5">{{ description }}</span>
    <form v-if="!isExclusao" action="">
      <div class="flex align-items-center gap-3 mb-5">
        <label for="nome" class="font-semibold w-6rem">Nome: </label>
        <InputText :v-model="objContato?.nome" id="nome" class="flex-auto" autocomplete="off" />
      </div>
      <div class="flex align-items-center gap-3 mb-5">
        <label for="email" class="font-semibold w-6rem">E-mail: </label>
        <InputText :v-model="objContato?.email" id="email" class="flex-auto" autocomplete="off" />
      </div>
      <div class="flex align-items-center gap-3 mb-5">
        <label for="telefone" class="font-semibold w-6rem">Telefone: </label>
        <InputText
          :v-model="objContato?.telefone"
          id="telefone"
          class="flex-auto"
          autocomplete="off"
        />
      </div>
    </form>
    <div class="flex justify-content-end gap-2">
      <Button
        type="button"
        label="Cancelar"
        severity="secondary"
        @click="$emit('closeModal')"
      ></Button>
      <Button type="button" label="Salvar" @click="salvarContato({} as Contato)"></Button>
    </div>
  </Dialog>
</template>
