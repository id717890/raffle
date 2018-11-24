<template>
  <b-container>
    <b-row align-h="center" class="mt-5">
      <b-col cols="5">
        <b-card class="p-3">
          <h3 class="mb-4">Login</h3>
          <b-form @submit="onSubmit" v-if="show">
      <b-form-group id="exampleInputGroup1"
                    label="Email address:"
                    label-for="exampleInput1"
                    >
        <b-form-input id="exampleInput1"
                      type="email"
                      v-model="form.email"
                      required
                      placeholder="Enter email">
        </b-form-input>
      </b-form-group>
      <b-form-group id="exampleInputGroup2"
                    label="Password:"
                    label-for="exampleInput2">
        <b-form-input id="exampleInput2"
                      type="password"
                      v-model="form.password"
                      required
                      placeholder="Enter password">
        </b-form-input>
      </b-form-group>

      <b-form-group id="exampleGroup4">
        <b-form-checkbox-group v-model="form.checked" id="exampleChecks">
          <b-form-checkbox value="remember">Remember me</b-form-checkbox>
        </b-form-checkbox-group>
      </b-form-group>
      <div class="d-flex justify-content-between">
        <div>
          <b-button type="submit" variant="primary">Submit</b-button>&nbsp;
        </div>
        <div>
          <b-button to="forgot">Forgot Password</b-button>
        </div>
      </div>
    </b-form>
        </b-card>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
export default {
  data () {
    return {
      showDismissibleAlert: false,
      form: {
        email: '',
        password: '',
        food: null,
        checked: []
      },
      show: true
    }
  },
  methods: {
    handleClick () {
      this.showDismissibleAlert = true
    },
    onSubmit (evt) {
      evt.preventDefault()
      alert(JSON.stringify(this.form))
    }
  }
}
</script>

