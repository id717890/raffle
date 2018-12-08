import Vue from 'vue'
import Router from 'vue-router'
// import HomePage from '@/components/Home'
// import Hello from '@/components/Hello'
import Forum from '@/components/Public/Forum'

Vue.use(Router)

export default new Router({
  routes: [
    {path: '/', name: 'Home', component: () => import('@/components/Home')},
    // {path: '/forum', name: 'Forum', component: () => import('@/components/Public/Forum')},
    {path: '/forum', name: 'Forum', component: Forum},
    {path: '/voting', name: 'Voting', component: () => import('@/components/Public/Voting')},
    {path: '/signin', name: 'Signin', component: () => import('@/components/Auth/SignIn')},
    {path: '/signup', name: 'Signup', component: () => import('@/components/Auth/SignUp')},
    {path: '/forgot', name: 'Forgot', component: () => import('@/components/Auth/Forgot')},
    {path: '/resetpassword', name: 'ResetPassword', component: () => import('@/components/Auth/ResetPassword')},
    {path: '/message', name: 'Message', component: () => import('@/components/Shared/Message')},
    {
      path: '/dashboard',
      name: 'Dashboard',
      redirect: {name: 'Gifts'},
      component: () => import('@/components/Private/Dashboard'),
      children: [
        {path: '/dashboard/gifts', name: 'Gifts', component: () => import('@/components/Private/Gift')},
        {path: '/dashboard/settings', name: 'Setting', component: () => import('@/components/Private/Setting')},
        {path: '/dashboard/other', name: 'Other', component: () => import('@/components/Private/other')}
      ]}
  ],
  mode: 'history'
})
