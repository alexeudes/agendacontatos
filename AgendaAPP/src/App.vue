<script setup lang="ts"></script>

<template>
  <h2>Agenda</h2>
  <div class="wrapper">
    <main>
      <RouterView />
    </main>
  </div>
  <!-- <Toolbar></Toolbar> -->

  <!-- Modal de Cadastro 
  <Dialog
    :visible="visibleCadastro"
    :header="header"
    :style="style"
    :description="'Informe os dados de cadastro do usuário'"
  ></Dialog> -->

  <!-- Modal de Edição
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
  </Dialog>-->
</template>

<style scoped>
h2 {
  text-align: center;
}
</style>
