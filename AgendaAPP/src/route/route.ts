import { createRouter, createWebHistory } from 'vue-router'

import DataTable from '@/components/DataTable.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: DataTable
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
