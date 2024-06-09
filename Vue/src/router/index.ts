import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/crear',
      name: 'crear',
      component: () => import('../views/CrearView.vue')
    },
    {
      path: '/editar/:id',
      name: 'editar',
      component: () => import('../views/EditarView.vue')
    }
  ]
})

export default router
