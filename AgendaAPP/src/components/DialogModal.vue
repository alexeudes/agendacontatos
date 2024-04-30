<script setup lang="ts">
import { reactive } from 'vue'
import Dialog from 'primevue/dialog'
import Button from 'primevue/button'

const props = defineProps({
  visible: {
    type: Boolean,
    required: true
  }
})
</script>

<template>
  <Dialog :visible="visible" modal header="Excluir Contato" style="width: 25rem">
    <span class="p-text-secondary block mb-5">Deseja mesmo excluir este contato?</span>
    <div class="flex justify-content-end gap-2">
      <Button
        type="button"
        label="Cancelar"
        severity="secondary"
        @click="$emit('closeModal')"
      ></Button>
      <Button
        type="button"
        severity="danger"
        label="Excluir"
        @click="$emit('excluirContato')"
      ></Button>
    </div>
  </Dialog>
</template>
