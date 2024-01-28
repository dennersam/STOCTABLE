export const navBarData = [
  {
    routeLink: 'dashboard',
    icon: '../../../../assets/img/svg/dashboard_icon.svg',
    label: 'Dashboard'
  },
  {
    routeLink: 'estoque',
    icon: '../../../../assets/img/svg/estoque_icon.svg',
    label: 'Estoque'
  },
  {
    routeLink: 'cadastro',
    icon: '../../../../assets/img/svg/estoque_icon.svg',
    label: 'Cadastro',
    items: [
      {
        routeLink: 'cadastro/produto',
        label: 'Produto'

      },
      {
        routeLink: 'cadastro/fornecedor',
        label: 'Fornecedor'
      },
      {
        routeLink: 'cadastro/cliente',
        label: 'Cliente'
      },
      {
        routeLink: 'cadastro/transportadora',
        label: 'Transportadora'
      }
    ]
  }
]
