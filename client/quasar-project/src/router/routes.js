const routes = [
  {
    path: '/',
    component: () => import('pages/ReportsPage.vue')
  },
  {
    path: '/salesSummary',
    component: () => import('src/pages/SalesSummaryPage.vue')
  },
  {
    path: '/salesPerformance',
    component: () => import('pages/SalesPerformancePage.vue')
  }
]

export default routes
