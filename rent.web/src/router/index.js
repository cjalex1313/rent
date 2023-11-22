import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import DefaultLayout from '../layouts/DefaultLayout.vue'
import AuthLayout from '../views/auth/AuthLayout.vue'
import LoginView from '../views/auth/LoginView.vue'
import RegisterView from '../views/auth/RegisterView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'default',
      component: DefaultLayout,
      children: [
        {
          path: '',
          name: 'home',
          component: HomeView
        },
        {
          path: '/my-properties',
          name: 'MyProperties',
          component: () => import('../views/properties/MyPropertiesView.vue')
        },
        {
          path: '/apartment/:id(\\d+)',
          name: 'Apartment',
          component: () => import('../views/properties/ApartmentView.vue')
        },
        {
          path: '/House/:id(\\d+)',
          name: 'House',
          component: () => import('../views/properties/HouseView.vue')
        },
        {
          path: '/search',
          name: 'Search',
          component: () => import('../views/properties/SearchView.vue')
        }
      ]
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
    },
    {
      path: '/auth',
      name: 'Auth',
      component: AuthLayout,
      children: [
        {
          path: 'login',
          name: 'Login',
          component: LoginView
        },
        {
          path: 'register',
          name: 'Register',
          component: RegisterView
        }
      ]
    }
  ]
})

export default router
