import Vue from 'vue'
import Router from 'vue-router'
// import HomePage from '@/components/Home'
// import Hello from '@/components/Hello'

Vue.use(Router)

export default new Router({
  routes: [
    {path: '/', name: 'Home', component: () => import('@/components/Home')},
    {path: '/forum', name: 'Forum', component: () => import('@/components/Public/Forum')},
    {path: '/voting', name: 'Voting', component: () => import('@/components/Public/Voting')},
    {path: '/signin', name: 'Signin', component: () => import('@/components/Auth/SignIn')},
    {path: '/signup', name: 'Signup', component: () => import('@/components/Auth/SignUp')},
    {path: '/forgot', name: 'Forgot', component: () => import('@/components/Auth/Forgot')},
    {path: '/resetpassword', name: 'ResetPassword', component: () => import('@/components/Auth/ResetPassword')},
    {path: '/dashboard', name: 'Dashboard', component: () => import('@/components/Private/Dashboard')}
  ],
  mode: 'history'
})
