import { AppBar, Toolbar, Typography, Container, Box, Button, Grid } from '@mui/material';

export default function Homepage() {
  return (
    <>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" style={{ flexGrow: 1 }}>
            GestorRH
          </Typography>
          <Button color="inherit">Planos</Button>
          <Button color="inherit">Funcionalidades</Button>
          <Button color="inherit">Representantes</Button>
          <Button color="inherit">Sobre</Button>
          <Button variant="contained" color="secondary">Comprar</Button>
        </Toolbar>
      </AppBar>

      <Container maxWidth="lg">
        <Box sx={{ mt: 8, textAlign: 'center' }}>
          <Typography variant="h1" color="primary" gutterBottom>
            Solução completa e digital para sua gestão de controle de ponto.
          </Typography>
          <Typography variant="body1" color="textSecondary" paragraph>
            Reduza em até <strong>85%</strong> o tempo gasto na sua gestão. O trabalhador ainda conta com todas as facilidades do GestorRH.
          </Typography>

          <Box sx={{ mt: 4 }}>
            <Button variant="contained" color="secondary" sx={{ mr: 2 }}>
              Solicitar Proposta
            </Button>
            <Button variant="outlined" color="primary">
              Fazer Login
            </Button>
          </Box>
        </Box>

        <Grid container spacing={4} sx={{ mt: 8 }}>
          <Grid item xs={12} sm={4}>
            <Box textAlign="center">
              <Typography variant="h4" color="primary">
                Gestão Completa
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={4}>
            <Box textAlign="center">
              <Typography variant="h4" color="primary">
                Líder de Mercado
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={4}>
            <Box textAlign="center">
              <Typography variant="h4" color="primary">
                Dados Estratégicos
              </Typography>
            </Box>
          </Grid>
        </Grid>
      </Container>
    </>
  );
};