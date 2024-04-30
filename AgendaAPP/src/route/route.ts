import { createRouter, createWebHistory } from 'vue-router'

import Main from '../pages/Main.vue'
import CadastrarContato from '@/pages/CadastrarContato.vue'
import EditarContato from '@/pages/EditarContato.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: Main
  },
  {
    path: '/new',
    name: 'cadastrar',
    component: CadastrarContato
  },
  {
    path: '/update/:id',
    name: 'editar',
    component: EditarContato
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
