<template>
<div style="height: 100%">
  <b-navbar toggleable="sm" type="dark" style="background: none !important">
    <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
    <b-navbar-brand to="/">Raffle</b-navbar-brand>
    <b-collapse is-nav id="nav_collapse">
      <b-navbar-nav>
        <b-nav-item :to="item.link" v-for="item in menu" :key="item.id">{{item.name}}</b-nav-item>
      </b-navbar-nav>

      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        <b-nav-item to="/signin" v-if="!isAuth">Sign In</b-nav-item>
        <b-nav-item to="/signup" v-if="!isAuth">Sign Up</b-nav-item>
        <b-nav-item to="dashboard" v-if="isAuth">Dashboard</b-nav-item>
        <b-nav-item @click="LogoutButton" v-if="isAuth">Logout</b-nav-item>

        <!-- <b-nav-form>
          <b-form-input size="sm" class="mr-sm-2" type="text" placeholder="Search"/>
          <b-button size="sm" class="my-2 my-sm-0" type="submit">Search</b-button>
        </b-nav-form> -->

        <!-- <b-nav-item-dropdown text="Lang" right>
          <b-dropdown-item href="#">EN</b-dropdown-item>
          <b-dropdown-item href="#">ES</b-dropdown-item>
          <b-dropdown-item href="#">RU</b-dropdown-item>
          <b-dropdown-item href="#">FA</b-dropdown-item>
        </b-nav-item-dropdown> -->

        <!-- <b-nav-item-dropdown right>
          <template slot="button-content">
            <em>User</em>
          </template>
          <b-dropdown-item href="#">Profile</b-dropdown-item>
          <b-dropdown-item href="#">Signout</b-dropdown-item>
        </b-nav-item-dropdown> -->
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
  <b-container fluid  style="height: 100%">
    <router-view></router-view>
  </b-container>
</div>
</template>

<script>
import {mapGetters, mapActions} from 'vuex'

const menu = [
  {id: 1, name: 'Forum', link: 'forum'},
  {id: 2, name: 'Voting', link: 'voting'}
]
export default {
  computed: {
    ...mapGetters(['isAuth'])
  },
  data () {
    return {
      menu: menu
    }
  },
  methods: {
    ...mapActions(['logout']),
    LogoutButton () {
      this.logout()
      this.$router.push('/')
    }
  }
}
</script>

