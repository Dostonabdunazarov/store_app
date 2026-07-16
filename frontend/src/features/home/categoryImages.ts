// Category card background photos (Unsplash), keyed by category slug.
// Kept on the frontend so cards look great without a DB image column; unknown
// slugs fall back to a gradient + icon in the card component.
const url = (id: string) => `https://images.unsplash.com/${id}?w=800&q=80&auto=format&fit=crop`

export const CATEGORY_IMAGES: Record<string, string> = {
  laptops: url('photo-1517336714731-489689fd1ca8'),
  tablets: url('photo-1544244015-0df4b3ffc6b0'),
  phones: url('photo-1511707171634-5f897ff02aa9'),
  gadgets: url('photo-1523275335684-37898b6baf30'),
  headsets: url('photo-1505740420928-5e560c06d30e'),
  smartwatches: url('photo-1546868871-7041f2a55e12'),
  tvs: url('photo-1593359677879-a4bb92f829d1'),
  monitors: url('photo-1527443224154-c4a3942d3acf'),
  peripherals: url('photo-1587829741301-dc798b83add3'),
  accessories: url('photo-1572569511254-d8f925fe2cbb'),
}
